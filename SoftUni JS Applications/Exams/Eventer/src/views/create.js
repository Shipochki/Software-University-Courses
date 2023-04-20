import { html } from "../../node_modules/lit-html/lit-html.js";
import { createEvent } from "../data/data.js";
import { createSubmitHandler } from "../util.js";

const createTemplete = (onCreate) => html`
<section id="create">
          <div class="form">
            <h2>Add Event</h2>
            <form class="create-form" @submit=${onCreate}>
              <input
                type="text"
                name="name"
                id="name"
                placeholder="Event"
              />
              <input
                type="text"
                name="imageUrl"
                id="event-image"
                placeholder="Event Image URL"
              />
              <input
                type="text"
                name="category"
                id="event-category"
                placeholder="Category"
              />


              <textarea
                id="event-description"
                name="description"
                placeholder="Description"
                rows="5"
                cols="50"
              ></textarea>
              
              <input
              type="text"
              name="date"
              id="date"
              placeholder="When?"
            />

              <button type="submit">Add</button>
            </form>
          </div>
        </section>
`

export async function createPage(ctx){
    ctx.render(createTemplete(createSubmitHandler(onCreate)));

    async function onCreate({name, imageUrl, category, description, date}, form){
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

        await createEvent(data);
        form.reset();
        ctx.page.redirect('/events');
    }
}