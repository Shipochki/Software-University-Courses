import { html } from "../../node_modules/lit-html/lit-html.js";
import { register } from "../data/auth.js";
import { createSubmitHandler } from "../util.js";

//Todo replace with actual view
const registerTemplate = (onregister) => html`
<h1>Register Page</h1>
<form @submit=${onregister}>
    <lable>Email: <input type="text" name="email"></lable>
    <lable>Password: <input type="password" name="password"></lable>
    <lable>Repeat: <input type="password" name="repass"></lable>
    <button>Register</button>
</form>
`;

export function registerPage(ctx){
    ctx.render(registerTemplate(createSubmitHandler(onregister)));

    async function onregister({email, password, repass}, form){
        if(email == '', password == ''){
            return alert('All fields are requires!');
        }

        if(password != repass){
            return alert('Passwords dont match!');
        }

        await register(email, password);
        form.reset();
        ctx.page.redirect('/');
    }
}