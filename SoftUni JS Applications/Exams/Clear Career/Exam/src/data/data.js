import { del, get, post, put } from "./api.js";

export async function getAllOffers() {
    return await get(`/data/offers?sortBy=_createdOn%20desc`);
}

export async function create(offer) {
    return await post('/data/offers', offer);
}

export async function getById(id) {
    return await get('/data/offers/' + id);
}

export async function editOfferById(id, offer) {
    return await put(`/data/offers/${id}`, offer);
}

export async function deleteOfferById(id) {
    return await del(`/data/offers/${id}`);
}

export async function apply(offerId) {
    return await post(`/data/applications`, offerId)
}

export async function getTotalApplications(offerId) {
    return await get(`/data/applications?where=offerId%3D%22${offerId}%22&distinct=_ownerId&count`);
}

export async function didUserApplied(offerId, userId) {
    return await get(`/data/applications?where=offerId%3D%22${offerId}%22%20and%20_ownerId%3D%22${userId}%22&count`
    );
}