"use strict";
var KTUsersAddUser = function () {
    const t = document.getElementById("kt_modal_add_user"),
        e = t.querySelector("#kt_modal_add_user_form"),

        n = new bootstrap.Modal(t);
    var theContact;
    return {
        init: function () {
            (() => {
                var o = FormValidation.formValidation(e, {
                    fields: {
                        seller_no: {
                            validators: {
                                notEmpty: {
                                    message: "Vergi kimlik numarasý zorunludur."
                                }
                            }
                        },
                        seller_name: {
                            validators: {
                                notEmpty: {
                                    message: "Satýcý ismi zorunludur."
                                }
                            }
                        },
                        seller_adress: {
                            validators: {
                                notEmpty: {
                                    message: "Satýcý adres zorunludur."
                                }
                            }
                        }
                    },
                    plugins: {
                        trigger: new FormValidation.plugins.Trigger,
                        bootstrap: new FormValidation.plugins.Bootstrap5({
                            rowSelector: ".fv-row",
                            eleInvalidClass: "",
                            eleValidClass: ""
                        })
                    }
                });
                const i = t.querySelector('[data-kt-users-modal-action="submit"]');
                i.addEventListener("click", (t => {
                    t.preventDefault(), o && o.validate().then((function (t) {
                         "Valid" == t ? (i.setAttribute("data-kt-indicator", "on"), i.disabled = !0, setTimeout((function () {
                            i.removeAttribute("data-kt-indicator"), i.disabled = !1,
                                 theContact = {

                                    selleNumber: parseInt($("[name='seller_no']").val()),
                                    sellerName: $("[name='seller_name']").val(),
                                    sellerAdress: $("[name='seller_adress']").val()
                                };
                             console.log(theContact);
                            $.ajax({
                                type: "POST",
                                url: "https://localhost:44323/api/seller/create",
                                contentType: "application/json; charset=utf-8",
                                data: JSON.stringify(theContact),
                                dataType: "json",
                                success: function (data) {
                                    Swal.fire({
                                        text: "Kayýt iþlemi baþarýlý!",
                                        icon: "success", buttonsStyling: !1, confirmButtonText: "Tamam,devam et!",
                                        customClass: { confirmButton: "btn btn-primary" }
                                    }).then((function (t) { t.isConfirmed && (e.reset()) }))
                                },
                                error: function (data) {
                                    Swal.fire({
                                        text: "Hata! Sistem yöneticisyle iletiþime geçiniz.'" + data + "'",
                                        icon: "error", buttonsStyling: !1, confirmButtonText: "Tamam,devam et!",
                                        customClass: { confirmButton: "btn btn-primary" }
                                    }).then((function (t) { t.isConfirmed && (e.reset()) }))
                                }

                            });

                        }), 2e3)) : Swal.fire({
                            text: "Hata! Sistem yöneticisyle iletiþime geçiniz.Henüz post metoduna girilmedi." ,
                            icon: "error",
                            buttonsStyling: !1,
                            confirmButtonText: "Ok, got it!",
                            customClass: {
                                confirmButton: "btn btn-primary"
                            }
                        })
                    }))
                })), t.querySelector('[data-kt-users-modal-action="cancel"]').addEventListener("click", (t => {
                    t.preventDefault(),
                        Swal.fire({
                        text: "Ýptal etmek istediðinize emnin misiniz?",
                        icon: "warning",
                        showCancelButton: !0,
                        buttonsStyling: !1,
                        confirmButtonText: "Evet, iptal et!",
                        cancelButtonText: "Hayýr, geridön",
                        customClass: {
                            confirmButton: "btn btn-primary",
                            cancelButton: "btn btn-active-light"
                        }
                    }).then((function (t) {
                        t.value ? (e.reset(), n.hide()) : "cancel" === t.dismiss && Swal.fire({
                            text: "Ýþlem iptal edilmedi!.",
                            icon: "error",
                            buttonsStyling: !1,
                            confirmButtonText: "Tamam anladým!",
                            customClass: {
                                confirmButton: "btn btn-primary"
                            }
                        })
                    }))
                })), t.querySelector('[data-kt-users-modal-action="close"]').addEventListener("click", (t => {
                    t.preventDefault(),
                        Swal.fire({
                        text: "Ýptal etmek istediðinize emnin misiniz?",
                        icon: "warning",
                        showCancelButton: !0,
                        buttonsStyling: !1,
                        confirmButtonText: "Evet, iptal et!",
                        cancelButtonText: "Hayýr, geridön",
                        customClass: {
                            confirmButton: "btn btn-primary",
                            cancelButton: "btn btn-active-light"
                        }
                    }).then((function (t) {
                        t.value ? (e.reset(), n.hide()) : "cancel" === t.dismiss && Swal.fire({
                            text: "Ýþleminiz iptal edilmedi!.",
                            icon: "error",
                            buttonsStyling: !1,
                            confirmButtonText: "Tamam anladým!",
                            customClass: {
                                confirmButton: "btn btn-primary"
                            }
                        })
                    }))
                }))
            })()
        }
    }
}();
KTUtil.onDOMContentLoaded((function () {
    KTUsersAddUser.init()
}));