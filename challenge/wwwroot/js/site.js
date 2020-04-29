// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function formatCPF(cpf) {
    cpf.mask('000.000.000-00', { reverse: true });
}

function formatPhoneNumber(phoneNumber) {
    phoneNumber.mask('+55 (00) 00000-0000', { reverse: false });
}