/*
Template Name: Spark - App Landing Page Template.
Author: GrayGrids
*/

(function () {
    //===== Prealoder

    window.onload = function () {
        window.setTimeout(fadeout, 500);
    }

    function fadeout() {
        document.querySelector('.preloader').style.opacity = '0';
        document.querySelector('.preloader').style.display = 'none';
    }


    /*=====================================
    Sticky
    ======================================= */
    window.onscroll = function () {
        var header_navbar = document.querySelector(".navbar-area");
        var sticky = header_navbar.offsetTop;

        var logo = document.querySelector('.navbar-brand img')
        if (window.pageYOffset > sticky) {
          header_navbar.classList.add("sticky");
          logo.src = 'assets/images/logo/logo.svg';
        } else {
          header_navbar.classList.remove("sticky");
          logo.src = 'assets/images/logo/white-logo.svg';
        }

        // show or hide the back-top-top button
        var backToTo = document.querySelector(".scroll-top");
        if (document.body.scrollTop > 50 || document.documentElement.scrollTop > 50) {
            backToTo.style.display = "flex";
        } else {
            backToTo.style.display = "none";
        }
    };

    // WOW active
    new WOW().init();

    //===== mobile-menu-btn
    let navbarToggler = document.querySelector(".mobile-menu-btn");
    navbarToggler.addEventListener('click', function () {
        navbarToggler.classList.toggle("active");
    });


    // Contactform Submit
    const onSubmitContact = function(event) {
        event.preventDefault();
        event.target.innerHTML = `
        <div class="modal-body contact-us">
            <p>
                Wir haben deine E-Mail Adresse erhalten und melden uns bei dir sobald der Launch beginnt.
            </p>
            <lottie-player src="https://assets8.lottiefiles.com/private_files/lf30_kdkhqgib.json"
            background="transparent" speed="1" style="width: 300px; height: 300px;" loop autoplay />
        </div>`;
    };

    let form = document.getElementById("contact-formular");
    let form2 = document.getElementById("contact-formular-2");

    form.addEventListener("submit", onSubmitContact, true);
    form2.addEventListener("submit", onSubmitContact, true);

})();