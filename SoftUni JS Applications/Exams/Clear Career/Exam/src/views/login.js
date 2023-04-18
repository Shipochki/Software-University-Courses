import { html } from "../../node_modules/lit-html/lit-html.js";
import { login } from "../data/auth.js";
import { createSubmitHandler } from "../util.js";

//Todo replace with actual view
const loginTemplate = (onLogin) => html`
<h1>Login Page</h1>
<form @submit=${onLogin}>
    <lable>Email: <input type="text" name="email"></lable>
    <lable>Password: <input type="password" name="password"></lable>
    <button>Login</button>
</form>
`;

export function loginPage(ctx){
    ctx.render(loginTemplate(createSubmitHandler(onLogin)));

    async function onLogin({email, password}, form){
        if(email == '' || password == ''){
            return alert('All fields are requires!');
        }

        await login(email, password);
        form.reset();
        ctx.page.redirect('/');
    }
}