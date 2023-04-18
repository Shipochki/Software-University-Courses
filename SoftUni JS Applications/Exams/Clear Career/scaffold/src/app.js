import page from '../node_modules/page/page.mjs';
import { render } from '../node_modules/lit-html/lit-html.js';
import { layoutTemple } from './views/layout.js';
import { getUserData } from './util.js';
import { homePage } from './views/home.js';

//Todo change render root depending on project HTML structure
const root = document.body;

page(decorateContext);
page('index.html', '/');
page('/', () => console.log('hello'));

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