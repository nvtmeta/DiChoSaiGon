// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/* When the user scrolls down, hide the navbar. When the user scrolls up, show the navbar */
var prevScrollpos = window.pageYOffset;
window.onscroll = function () {
    var currentScrollPos = window.pageYOffset;
    if (prevScrollpos > currentScrollPos) {
        document.getElementById("navbar").style.top = "20px";
    } else {
        document.getElementById("navbar").style.top = "-100px";
    }
    prevScrollpos = currentScrollPos;
}


// toast

// guide

//  < body >

//                              <div id="toast"></div>

//                              <div>
//                                  <div onclick="showSuccessToast();" class="btn btn--success">Show success toast</div>
//                                  <div onclick="showErrorToast();" class="btn btn--danger">Show error toast</div>
//                              </div>

//                              <script src="toast.js">
//                                  function showSuccessToast() {
//                                      toast({
//                                          title: "Thành công!",
//                                          message: "Bạn đã đăng ký thành công tài khoản tại F8.",
//                                          type: "success",
//                                          duration: 5000
//                                      });
//}

//                                  function showErrorToast() {
//                                      toast({
//                                          title: "Thất bại!",
//                                          message: "Có lỗi xảy ra, vui lòng liên hệ quản trị viên.",
//                                          type: "error",
//                                          duration: 5000
//                                      });
//}
//                              </script>
//                          </body >




// Toast function
function toast({ title = "", message = "", type = "", duration = 14000 }) {
    const main = document.getElementById('toast')
    console.log(main)
    if (main) {
        const icons = {
            success: "fas fa-check-circle",
            info: "fas fa-info-circle",
            warning: "fas fa-exclamation-circle",
            error: "fas fa-exclamation-circle"
        }
        const icon = icons[type]
        const toast = document.createElement('div')
        toast.classList.add('toast', `toast--${type}`)
        const delay = (duration / 1000).toFixed(2)

        toast.style.animation = `
        slideInLeft ease 9s,
         fadeOut linear 1s ${delay}s forwards`
        //           fadeOut linear 1s ${delay}s forwards;` sai vi 
        // thua dau ; o cuoi forwards

        toast.innerHTML =
            `<div class="toast__icon">
                               <i class="${icon}"></i>
                           </div>
                           <div class="toast__body">
                               <h3 class="toast__title">${title}</h3>
                               <p class="toast__msg">${message}</p>
                           </div>
                           <div class="toast__close">
                               <i class="fas fa-times"></i>
                           </div>`

        main.appendChild(toast)
        const autotime = setTimeout(() => {
            main.removeChild(toast)
        }, duration + 1000);

        toast.onclick = (e) => {
            if (e.target.closest('.toast__close')) {
                main.removeChild(toast)
                clearTimeout(autotime)
            }
        }

    }
}
function showSuccessToast() {
    toast({
        title: "Thành công!",
        message: "Bạn đã đăng ký thành công tài khoản tại F8.",
        type: "success",
        duration: 5000
    });
}

function showErrorToast() {
    toast({
        title: "Thất bại!",
        message: "Có lỗi xảy ra, vui lòng liên hệ quản trị viên.",
        type: "error",
        duration: 5000
    });
}



// show modal cart

const cart_btn = document.getElementsByClassName("cart_btn")[0]

const open_cart = document.getElementsByClassName("open_cart")[0]



console.log(open_cart);

function showLogIn() {
    open_cart.classList.remove('hidden');
    console.log('ok');
};

function hiddenLogIn() {
    open_cart.classList.add('hidden');
};



window.onload(hiddenLogIn())


cart_btn.addEventListener('click', showLogIn)