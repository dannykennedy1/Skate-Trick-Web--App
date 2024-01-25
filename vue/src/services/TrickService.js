import axios from "axios";

const http = axios.create({ baseURL: "https://localhost:44315" });

export default {
  listTricks() {
    return http.get("/trick");
  },
  addTrick(newTrick) {
    return http.post("/trick/createTrick", newTrick);
  },
  updateTrick(updatedTrick) {
    return http.put(`/trick/${updatedTrick.id}`, updatedTrick);
  },
  getTrick(id) {
    return http.get(`/trick/${id}`);
  },
};