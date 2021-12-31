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
                                    message: "Vergi kimlik numaras� zorunludur."
                                }
                            }
                        },
                        seller_name: {
                            validators: {
                                notEmpty: {
                                    message: "Sat�c� ismi zorunludur."
                                }
                            }
                        },
                        seller_adress: {
                            validators: {
                                notEmpty: {
                                    message: "Sat�c� adres zorunludur."
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
                                        text: "Kay�t i�lemi ba�ar�l�!",
                                        icon: "success", buttonsStyling: !1, confirmButtonText: "Tamam,devam et!",
                                        customClass: { confirmButton: "btn btn-primary" }
                                    }).then((function (t) { t.isConfirmed && (e.reset()) }))
                                },
                                error: function (data) {
                                    Swal.fire({
                                        text: "Hata! Sistem y�neticisyle ileti�ime ge�iniz.'" + data + "'",
                                        icon: "error", buttonsStyling: !1, confirmButtonText: "Tamam,devam et!",
                                        customClass: { confirmButton: "btn btn-primary" }
                                    }).then((function (t) { t.isConfirmed && (e.reset()) }))
                                }

                            });

                        }), 2e3)) : Swal.fire({
                            text: "Hata! Sistem y�neticisyle ileti�ime ge�iniz.Hen�z post metoduna girilmedi." ,
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
                        text: "�ptal etmek istedi�inize emnin misiniz?",
                        icon: "warning",
                        showCancelButton: !0,
                        buttonsStyling: !1,
                        confirmButtonText: "Evet, iptal et!",
                        cancelButtonText: "Hay�r, gerid�n",
                        customClass: {
                            confirmButton: "btn btn-primary",
                            cancelButton: "btn btn-active-light"
                        }
                    }).then((function (t) {
                        t.value ? (e.reset(), n.hide()) : "cancel" === t.dismiss && Swal.fire({
                            text: "��lem iptal edilmedi!.",
                            icon: "error",
                            buttonsStyling: !1,
                            confirmButtonText: "Tamam anlad�m!",
                            customClass: {
                                confirmButton: "btn btn-primary"
                            }
                        })
                    }))
                })), t.querySelector('[data-kt-users-modal-action="close"]').addEventListener("click", (t => {
                    t.preventDefault(),
                        Swal.fire({
                        text: "�ptal etmek istedi�inize emnin misiniz?",
                        icon: "warning",
                        showCancelButton: !0,
                        buttonsStyling: !1,
                        confirmButtonText: "Evet, iptal et!",
                        cancelButtonText: "Hay�r, gerid�n",
                        customClass: {
                            confirmButton: "btn btn-primary",
                            cancelButton: "btn btn-active-light"
                        }
                    }).then((function (t) {
                        t.value ? (e.reset(), n.hide()) : "cancel" === t.dismiss && Swal.fire({
                            text: "��leminiz iptal edilmedi!.",
                            icon: "error",
                            buttonsStyling: !1,
                            confirmButtonText: "Tamam anlad�m!",
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