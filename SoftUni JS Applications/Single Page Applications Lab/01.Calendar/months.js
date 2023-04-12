import { getDays } from "./days.js";
import { getYears } from "./years.js";

const section = document.getElementById('years');

export function getMonths(year) {
    const yearSection = document.getElementById(`year-${year}`)
    const sections = document.querySelectorAll('section');
    sections.forEach(s => s.style.display = 'none');

    yearSection.style.display = 'block';
    const months = yearSection.querySelectorAll('div');
    months.forEach(m => m.parentNode.addEventListener('click', () => { getDays(year, m.textContent) }))
    yearSection.querySelector('caption').addEventListener('click', getYears);
}