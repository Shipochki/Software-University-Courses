import { get, post } from "./api.js";

export async function getAllOffers(){
    return await get(`/data/offers?sortBy=_createdOn%20desc`);
}

export async function create(offer){
    return await post('/data/offers', offer);
}
