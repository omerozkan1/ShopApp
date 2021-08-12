var detail = {

    PruductDetail: function () {
        $('.piece .plus').click(function (e) {
            var amountInput = $(this).parents('.amountBox').find('.input_amount');
            e.preventDefault();
            if (parseInt(amountInput.val()) >= amountInput.attr('max')) return false;
            var newAdult = parseInt(amountInput.val()) + 1;
            amountInput.val(newAdult);
        });

        $('.piece .minus').click(function (e) {
            var amountInput = $(this).parents('.amountBox').find('.input_amount');
            e.preventDefault();
            if (parseInt(amountInput.val()) > 1) {
                var newAdult = parseInt(amountInput.val()) - 1;
                amountInput.val(newAdult);
            }
        });

        $('.productsDetail .tabButtonBox a').click(function () {
            $('.productsDetail .tabButtonBox a').removeClass('active');
            $(this).addClass('active');
            var index = $(this).index();
            $('.tabPage').removeClass('active');
            $('.tabPage').eq(index).addClass('active');
        });
    },
    init: function () {
        this.PruductDetail();
/*        this.ShoppingCart();*/
    },

};
$(function () {
    detail.init();
});