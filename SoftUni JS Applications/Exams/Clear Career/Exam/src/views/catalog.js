import { html } from "../../node_modules/lit-html/lit-html.js";

const cardTemplete = (offer) => html`
<div class="offer">
            <img src="./images/example1.png" alt="example1" />
            <p>
              <strong>Title: </strong><span class="title">Sales Manager</span>
            </p>
            <p><strong>Salary:</strong><span class="salary">1900</span></p>
            <a class="details-btn" href="">Details</a>
          </div>
`