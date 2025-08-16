// Controllers/CartController.js
import { CartService } from '../Services/CartService.js';

export class CartController {
    constructor(cartService = new CartService()) {
        this.cartService = cartService;
    }

    init() {
        document.querySelectorAll(".add-to-cart-btn").forEach(button => {
            button.addEventListener("click", async (e) => {
                e.preventDefault();

                const productId = button.dataset.productId;
                let quantity = document.getElementById("quantity");
                if(quantity == null) {
                    quantity = 1;
                }
                quantity = Number(quantity.value ?? 1);
                const price = button.dataset.price;
                
                console.log("Dodajem u korpu...", productId, quantity, price);

                try {
                    await this.cartService.add(productId, quantity, price);
                    alert("Proizvod je uspešno dodat u korpu!");
                } catch (ex) {
                    alert("Greška pri dodavanju u korpu!");
                    console.error(ex);
                }
            });
        });
    }


}
