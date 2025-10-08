import { hotelUseCase } from "../../usecases/hotelUseCase.js";

export function adminHotelsPage() {
  const labels = { name: "Name", city: "City", address: "Address", description: "Description" };

  return {
    hotels: [],
    async init() { this.hotels = await hotelUseCase.getAll(); },

    openAdd() {
      window.dispatchEvent(new CustomEvent("modal:show", {
        detail: {
          title: "Add Hotel",
          data: { name: "", city: "", address: "", description: "" },
          onSave: async (payload) => { await hotelUseCase.create(payload); await this.init(); },

          labels,
          mode: "create"
        }
      }));
    },

    openEdit(hotel) {
      window.dispatchEvent(new CustomEvent("modal:show", {
        detail: {
          title: "Edit Hotel",
          data: { ...hotel },
          onSave: async (payload) => { await hotelUseCase.update(hotel.id, payload); await this.init(); },
          original: hotel,   // pass previous state for diffs
          labels,
          mode: "edit"
        }
      }));
    },

    async deleteHotel(id) {
      if (!confirm("Delete this hotel?")) return;
      await hotelUseCase.delete(id);
      await this.init();
    }
  };
}
