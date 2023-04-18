import { html } from "../../node_modules/lit-html/lit-html.js";
import { getAllOffers } from "../data/data.js";

const catalogTemplete = (offers) => html`
<section id="dashboard">
  <h2>Job Offers</h2>
  ${offers.length != 0 ? 
    offers.map((o) => html` 
    <div class="offer">
      <img src="${o.imageUrl}" alt="example1" />
      <p>
        <strong>Title: </strong><span class="title">${o.title}</span>
      </p>
      <p><strong>Salary:</strong><span class="salary">${o.salary}</span></p>
      <a class="details-btn" href="/details/${o._id}">Details</a>
    </div>`) : 
    html`<h2>No offers yet.</h2>`}
</section>
`

export async function catalogPage(ctx){
  const offers = await getAllOffers();
  console.log(offers);
  ctx.render(catalogTemplete(offers));
}

