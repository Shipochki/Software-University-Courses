import page from '../node_modules/page/page.mjs';
import { render } from '../node_modules/lit-html/lit-html.js';
import { getUserData } from './util.js';
import { layoutTemple } from './views/layout.js';
import { homePage } from './views/home.js';
import { loginPage } from './views/login.js';
import { registerPage } from './views/register.js';
import { logout } from './data/auth.js';

//Todo change render root depending on project HTML structure
const root = document.getElementById('wrapper');

page(decorateContext);
page('/index.html', '/');
page('/', homePage);
page('/login', loginPage)
page('/register', registerPage)
page('/logout', logoutAction)

page.start();

function decorateContext(ctx, next) {
    ctx.render = renderView;

    next();
}

//Todo Inject dependencies
function renderView(content) {
    const userData = getUserData();
    render(layoutTemple(userData, content), root)
}

function logoutAction(ctx){
    logout();
    ctx.page.redirect('/');
}