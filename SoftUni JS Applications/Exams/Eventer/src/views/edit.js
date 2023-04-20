import { html } from "../../node_modules/lit-html/lit-html.js";
import { editEventById, getEventById } from "../data/data.js";
import { createSubmitHandler } from "../util.js";

const editTemplete = (onEdit, event) => html`
<section id="create">
          <div class="form">
            <h2>Add Event</h2>
            <form class="create-form" @submit=${onEdit}>
              <input
                type="text"
                name="name"
                id="name"
                placeholder="Event"
                value="${event.name}"
              />
              <input
                type="text"
                name="imageUrl"
                id="event-image"
                placeholder="Event Image URL"
                value="${event.imageUrl}"
              />
              <input
                type="text"
                name="category"
                id="event-category"
                placeholder="Category"
                value="${event.category}"
              />


              <textarea
                id="event-description"
                name="description"
                placeholder="Description"
                rows="5"
                cols="50"
              >${event.description}</textarea>
              
              <input
              type="text"
              name="date"
              id="date"
              placeholder="When?"
              value="${event.date}"
            />

              <button type="submit">Add</button>
            </form>
          </div>
        </section>
`

export async function editPage(ctx){
    const eventId = ctx.params.id;
    const event = await getEventById(eventId);
    ctx.render(editTemplete(createSubmitHandler(onEdit), event));

    async function onEdit({name, imageUrl, category, description, date}, form){
        if(name == '' || imageUrl == '' || category == '' || description == '' 
        || date == ''){
            return alert('All fields are requires!');
        }

        const data = {
            name: name,
            imageUrl: imageUrl,
            category: category,
            description: description,
            date: date
        }

        await editEventById(eventId, data);
        ctx.page.redirect(`/details/${eventId}`);
    }
}