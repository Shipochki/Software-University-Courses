import { html } from "../../node_modules/lit-html/lit-html.js";
import { deleteOfferById } from "../data/data.js";
import { apply } from "../data/data.js";
import { getTotalApplications } from "../data/data.js";
import { didUserApplied, getById } from "../data/data.js";

const detailTemplete = (
  offer,
  onDelete,
  totalApplicationsCount,
  onClickApplication,
  didUserApply,
  id
  ) => html`
<section id="details">
          <div id="details-wrapper">
            <img id="details-img" src="${offer.imageUrl}" alt="example1" />
            <p id="details-title">${offer.title}</p>
            <p id="details-category">
              Category: <span id="categories">${offer.category}</span>
            </p>
            <p id="details-salary">
              Salary: <span id="salary-number">${offer.salary}</span>
            </p>
            <div id="info-wrapper">
              <div id="details-description">
                <h4>Description</h4>
                <span>${offer.description}</span>
              </div>
              <div id="details-requirements">
                <h4>Requirements</h4>
                <span>${offer.requirements}</span>
              </div>
            </div>
            <p>Applications: <strong id="applications">${totalApplicationsCount}</strong></p>
            ${localStorage != null ? html`
              ${offer._ownerId == id ? html
              `<div id="action-buttons">
                <a href="/edit/${offer._id}" id="edit-btn">Edit</a>
                <a href="#" id="delete-btn" @click=${onDelete}>Delete</a>` 
                : null}
              ${(() => {
                if(didUserApply == 0){
                    return html` <a href="javascript:void(0)" @click=${onClickApplication} id="apply-btn">Apply</a>`;
                }
              })()}`
            : null}
            </div>
          </div>
        </section>
`

export async function detailsPage(ctx){
    const id = ctx.params.id;
    const offer = await getById(id)
    const user = ctx.user;

    let userId;
    let totalApplicationsCount;
    let didUserApply;

  	console.log(localStorage.getItem('_id'));

    if(user != null){
      userId = user._id;
      didUserApply = await didUserApplied(id, userId);
    }

    totalApplicationsCount = await getTotalApplications(id);

    ctx.render(
      detailTemplete(
        offer,
        onDelete,
        totalApplicationsCount,
        onClickApplication,
        didUserApply,
        id
      )
    );

    async function onClickApplication() {
      const donation = {
        offerId,
      };
      await apply(donation);

      totalApplicationsCount = await getTotalApplications(id);
      didUserApply = await didUserApplied(id, userId);
      ctx.render(
        detailTemplete(
          offer,
          onDelete,
          totalApplicationsCount,
          onClickApplication,
          didUserApplied,
          id
        )
      )
    }

    async function onDelete(){
      const confirmed = confirm('Are you sure?');
      if(confirmed){
        await deleteOfferById(id);
        ctx.page.redirect('/');
      }
    }
}