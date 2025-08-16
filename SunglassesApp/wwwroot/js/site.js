import { CartController } from "./Controllers/CartController.js";
import { CartService } from "./Services/CartService.js";

const cartService = new CartService();
const cartController = new CartController(cartService);

window.addEventListener("DOMContentLoaded", () => {
    cartController.init();
});