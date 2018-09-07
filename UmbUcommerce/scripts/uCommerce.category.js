(function () {
    var categoryId = $('#category-id').val();
    var catalogId = $('#catalog-id').val();
    var i = 0;
    var prices = document.querySelectorAll('[data-productsku]');

    for (i ; i < prices.length; i++) {
        var currentPriceElement = prices[i];
        var currentSku = currentPriceElement.dataset.productsku;
        var currentJQelement = $(prices[i]);

        currentJQelement.prepend('<img src="/img/loader.gif" class="product-spinner" style="height: 20px;">');

        $.uCommerce.getProductInformation({
            CatalogId: parseInt(catalogId),
            CategoryId: parseInt(categoryId),
            Sku: currentSku
        },
            function (data) {
                if (data.PriceCalculation.IsDiscounted) {
                    document.querySelector("h6[data-productsku='" + data.Sku + "']").innerHTML = data.PriceCalculation.ListPrice.Amount.DisplayValue;
                    $('#' + data.Sku).find('.item-price').addClass('strike-through-price');
                    $('<p class="item-discounted-price">' + data.PriceCalculation.YourPrice.Amount.DisplayValue + '</p>').insertAfter($('#' + data.Sku).find('.item-price'));
                } else {
                    document.querySelector("h6[data-productsku='" + data.Sku + "']").innerHTML = data.PriceCalculation.YourPrice.Amount.DisplayValue;
                }

                var product = $('#' + data.Sku);

                var productContainer = product.find('.product-container');
                var productName = product.find('a.product-link');
                //var productButton = $('a.product-link');

                productContainer.click(function () {
                    window.location = data.NiceUrl;
                });

                productContainer.css('cursor', 'pointer');
                productName.attr('href', data.NiceUrl);
                //productButton.attr('href', data.NiceUrl);
            });
    }
})()