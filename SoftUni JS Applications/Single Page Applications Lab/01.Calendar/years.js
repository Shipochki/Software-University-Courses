import { getMonths } from "./months.js";

const section = document.getElementById('years');
const divs = section.querySelectorAll('div');

export function getYears() {
    const sections = document.querySelectorAll('section');
    sections.forEach(s => s.style.display = 'none');
    section.style.display = 'block';
    divs.forEach(d => d.parentNode.addEventListener('click', () => { getMonths(d.textContent) }))
}