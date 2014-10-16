$(function () {
  $('.submition-indicator').text('Сталась помилка. Спробуйте іще раз.');
  $('.flexslider').flexslider({
      animation: "slide",
      controlsContainer: ".slide-show-pagination",
      directionNav: false
  });
  $('#plusgallery').plusGallery();
  $('.accordion-sport').accordion();

  function addErrorState($element) {
    $element.parent().addClass('has-error');
  }

  function removeErrorState() {
    $(this).parent().removeClass('has-error');
    $(this).unbind('focus');
  }

  $('.form').submit(function () {
    var $inputs = $('#full-name, #city, #faculty, #phone'),
        validationError = false;

    $inputs.each(function (index, input) {
      if (input.value.length === 0 || input.value == 0) {
        var $element = $(input);
        addErrorState($element);
        $element.focus(removeErrorState);
        validationError = true;
      }
    });
    if (validationError)
      return false;

    var $submitionIndicator = $('.submition-indicator'),
        $formButtons = $('.form').find('button, input')
    $submitionIndicator.removeClass('success error').text('').show();
    $formButtons.prop('disabled', 'disabled');

    $.ajax({
      url: "/profkom/application",
      type: "POST",
      data: {
        FullName: $('#full-name').val(),
        City: $('#city').val(),
        FacultyId: $('#faculty').val(),
        Phone: $('#phone').val()
      },
      success: function (data) {
        if (data.message === 'success') {
          $submitionIndicator.addClass('success');
          $submitionIndicator.text(data.text);
        } else
          this.error(data);
      },
      error: function (data) {
        $formButtons.prop('disabled', '');
        $submitionIndicator.removeClass('success').addClass('error').text('Сталась помилка. Спробуйте іще раз.');
      }
    });
    return false;
  });

  //Google analytics
  (function (i, s, o, g, r, a, m) {
      i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
          (i[r].q = i[r].q || []).push(arguments)
      }, i[r].l = 1 * new Date(); a = s.createElement(o),
      m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
  })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

  ga('create', 'UA-42620869-1', 'studprofkom-uad.lviv.ua');
  ga('send', 'pageview');
});