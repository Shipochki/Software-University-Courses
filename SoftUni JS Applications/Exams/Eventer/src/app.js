import page from "../node_modules/page/page.mjs";
import { render } from "../node_modules/lit-html/lit-html.js";
import { getUserData } from "./util.js";
import { layoutTemple } from "./views/layout.js";
import { homePage } from "./views/home.js";
import { loginPage } from "./views/login.js";
import { logout } from "./data/auth.js";
import { registerPage } from "./views/register.js";
import { eventsPage } from "./views/events.js";
import { detailsPage } from "./views/details.js";

const root = document.getElementById('wrapper');

page(decorateContext);
page('/index.html', '/');
page('/', homePage);
page('/login', loginPage);
page('/logout', logoutAction);
page('/register', registerPage);
page('/events', eventsPage);
page('/details/:id', detailsPage);

page.start();

function decorateContext(ctx, next){
    ctx.render = renderView;

    next();
}

function renderView(content){
    const userData = getUserData();
    render(layoutTemple(userData, content), root);
}

function logoutAction(ctx){
    logout();
    ctx.page.redirect('/');
}