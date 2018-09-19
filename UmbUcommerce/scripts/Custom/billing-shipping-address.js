$(document).ready(function () {
    $("#IsShippingAddressDifferent").change(function () {
        if (this.checked) {
            $('.shipping_input_field').show();
            Validate.shippingEnabled = true;
        } else {
            Validate.shippingEnabled = false;
            $('.shipping_input_field').hide();
        }
    });


    $("form.validate").on('submit', function (e) {
        //Hide button on click
        $(this).find(".bigshop-btn").css("display", "none");
        $('.billing-container').find('.required').each(function () {
            Validate.ElemetsNeedsToValidate.push($(this)[0].id);            
        });
        if (Validate.shippingEnabled) {
            $('.shipping_input_field').find('.required').each(function () {
                Validate.ElemetsNeedsToValidate.push($(this)[0].id);               
            });
        }
        
        if (Validate.validateForm($(this))) {
            e.preventDefault();
            //Show button if error is there
            $(this).find(".bigshop-btn").css("display", "inline-block");
        }
    });

    var Validate = {
        ElemetsNeedsToValidate: [],
        shippingEnabled: false,       
        validateForm: function (_this) {
            var th = _this,                
                error = false,
                re = new RegExp('-', 'g');           
            _this.find('.error-message').hide();
            $.each(Validate.ElemetsNeedsToValidate, function (index, value) {                
                var element = th.find("#" + value),
                    value = element.val();

                if (
                    (value.length == 0) ||
                    (element.attr('data-email')==="true" && !Validate.validateEmail(value))
                ) {                    
                    element.closest('div').find('.error-message').show();
                    error = true;
                }
            });

                           
            return error;
           
        },
        validateDropdown: function (th) {

            if (th.find('option').length == 0)
                return true;

            var s = th.find("option:selected");

            if (s.text() === s.val())
                return false;
            else
                return true;
        },

        validateEmail: function (email) {
            var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(email);
        },

        validateString: function (str) {
            var re = /^[\u0627-\u064A\u0430-\u044f\u0410-\u042Fa-zA-Z-\s]+$/;
            return re.test(str);
        }
    };   

});
