

export class CartService {

    async add(productId, quantity, price) {
        return await axios.post("/api/Cart/Add", {
            ProductId: productId,
            Quantity: quantity,
            Price: price
        })
    }

    async get() {
        return await axios.get("/api/Cart");
    }

}