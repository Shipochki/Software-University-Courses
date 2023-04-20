import { del, get, post, put } from "./api.js";

export async function getAllEvents(){
    return await get(`/data/events?sortBy=_createdOn%20desc`);
}

export async function getEventById(id){
    return await get(`/data/events/${id}`);
}

export async function getTotalGoing(eventId){
    return await get(`/data/going?where=eventId%3D%22${eventId}%22&distinct=_ownerId&count`);
}

export async function didUserGoingTo(eventId, userId){
    return await get(`/data/going?where=eventId%3D%22${eventId}%22%20and%20_ownerId%3D%22${userId}%22&count`)
}

export async function deleteEvent(eventId){
    return await del(`/data/events/${eventId}`);
}

export async function editEventById(eventId, event){
    return await put(`/data/events/${eventId}`, event);
}

export async function createEvent(event){
    return await post(`/data/events`, event);
}

export async function going(eventId){
    return await post(`/data/going`, eventId);
}