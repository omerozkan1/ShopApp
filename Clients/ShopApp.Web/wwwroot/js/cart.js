var detail = {

    Basket: function () {


        $('.add').click(function (e) {
            var amountInput = $('#input_amount');
            e.preventDefault();
            if (parseInt(amountInput.val()) >= amountInput.attr('max')) return false;
            var newAdult = parseInt(amountInput.val()) + 1;
            amountInput.val(newAdult);
        });

        $('.sub').click(function (e) {
            var amountInput = $('#input_amount');
            e.preventDefault();
            if (parseInt(amountInput.val()) > 0) {
                var newAdult = parseInt(amountInput.val()) - 1;
                amountInput.val(newAdult);
            }
        });


        $('.add-to-cart').click(function () {
            productId = $(this).attr('dataid');
            var piece = $('#input_amount').val();
            addBasketMultiple(productId, piece);
        });


        function addBasketMultiple(productId, quantity) {
            console.log(quantity);
            $.ajax({
                type: "POST",
                data: { productId: productId, quantity: quantity },
                url: "/Basket/AddBasketItem",
                success: function (data) {
                    window.location = "/Basket/Index";
                },
                error: function (xhr, ajaxOptions, thrownError) {
                }

            });
        }

    },

    init: function () {
        this.Basket();
    },
};
$(function () {
    detail.init();
});