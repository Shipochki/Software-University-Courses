import page from "../node_modules/page/page.mjs";
import { render } from "../node_modules/lit-html/lit-html.js";
import { getUserData } from "./util.js";
import { layoutTemple } from "./views/layout.js";
import { homePage } from "./views/home.js";

const root = document.getElementById('wrapper');

page(decorateContext);
page('/index.html', '/');
page('/', homePage)

page.start();

function decorateContext(ctx, next){
    ctx.render = renderView;

    next();
}

function renderView(content){
    const userData = getUserData();
    render(layoutTemple(userData, content), root);
}