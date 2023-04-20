import { get } from "./api.js";

export async function getAllEvents(){
    return await get(`/data/events?sortBy=_createdOn%20desc`);
}