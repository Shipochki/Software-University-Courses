import { html } from "../../node_modules/lit-html/lit-html.js";
import { deleteEvent, getEventById, getTotalGoing, going, didUserGoingTo } from "../data/data.js";
import { getUserData } from "../util.js";

const detailsTemplete = (
    event,
    countGoing,
    isOwner,
    onDelete,
    didUserGoing,
    isLoggedIn,
    onClickGoing) => html`
<section id="details">
<div id="details-wrapper">
  <img id="details-img" src="${event.imageUrl}" alt="example1" />
  <p id="details-title">${event.name}</p>
  <p id="details-category">
    Category: <span id="categories">${event.category}</span>
  </p>
  <p id="details-date">
    Date:<span id="date">${event.date}</span></p>
  <div id="info-wrapper">
    <div id="details-description">
      <span>
      ${event.description}
        </span>
    </div>

  </div>

  <h3>Going: <span id="go">${countGoing}</span> times.</h3>
  <div id="action-buttons">
  ${isOwner ? html`
    <a href="/edit/${event._id}" id="edit-btn">Edit</a>
    <a href="javascrip:void(0)" id="delete-btn" @click=${onDelete}>Delete</a>
  `: ''}
  ${(() => {
    if(didUserGoing == 0){
        if(isLoggedIn && !isOwner){
            return html`
            <a href="javascipt:void(0)" id="go-btn" @click=${onClickGoing}>Going</a>
            `
        }
    }
  })()}  
  </div>
</div>
</section>
`

export async function detailsPage(ctx){
    const eventId = ctx.params.id;     
    const event = await getEventById(eventId);
    const user = getUserData();

    let userId;
    let totalGoingCount;
    let didUserGoing;

    if(user != null){
        userId = user._id;
        didUserGoing = await didUserGoingTo(eventId, userId);
    }

    const isOwner = user && event._ownerId == user._id;
    const isLoggedIn = user !== undefined;

    totalGoingCount = await getTotalGoing(eventId);

    ctx.render(detailsTemplete(
        event,
        totalGoingCount,
        isOwner,
        onDelete,
        didUserGoing,
        isLoggedIn,
        onClickGoing
    ));

    async function onClickGoing(){
        const donation = {
            eventId,
        };
        await going(donation);

        totalGoingCount = await getTotalGoing(eventId);
        didUserGoing = await didUserGoingTo(eventId, userId);
        ctx.render(detailsTemplete(
            event,
            totalGoingCount,
            isOwner,
            onDelete,
            didUserGoing,
            isLoggedIn,
            onClickGoing
        ));
    };

    async function onDelete(){
        const confirmed = confirm('Are you sure?');
        if(confirmed){
            await deleteEvent(eventId);
            ctx.page.redirect('/');
        }
    };
}