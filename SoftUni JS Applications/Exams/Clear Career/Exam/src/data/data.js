import { get } from "./api.js";

export async function getAllOffers(){
    const offers = await get(`/data/offers?sortBy=_createdOn%20desc`);
    console.log(offers);
    return offers;
}