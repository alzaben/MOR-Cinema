
function calculateTotalPayment() {
    // Get the selected snack and size
    var snackSelect = document.getElementById("ddlSnacks");
    var snackValue = snackSelect.options[snackSelect.selectedIndex].value;
    var snackPrice = parseFloat(snackSelect.options[snackSelect.selectedIndex].getAttribute("data-price"));

    var sizeSelect = document.querySelector('input[name="rbSize"]:checked');
    var sizePrice = parseFloat(sizeSelect.getAttribute("data-price"));

    // Get the selected sandwich and size
    var sandwichSelect = document.getElementById("ddlSandwish");
    var sandwichValue = sandwichSelect.options[sandwichSelect.selectedIndex].value;
    var sandwichPrice = parseFloat(sandwichSelect.options[sandwichSelect.selectedIndex].getAttribute("data-price"));

    var sandwichSizeSelect = document.querySelector('input[name="rbSize3"]:checked');
    var sandwichSizePrice = parseFloat(sandwichSizeSelect.getAttribute("data-price"));

    // Get the selected drink and size
    var drinkSelect = document.getElementById("ddlDrinks");
    var drinkValue = drinkSelect.options[drinkSelect.selectedIndex].value;
    var drinkPrice = parseFloat(drinkSelect.options[drinkSelect.selectedIndex].getAttribute("data-price"));

    var drinkSizeSelect = document.querySelector('input[name="rbSize1"]:checked');
    var drinkSizePrice = parseFloat(drinkSizeSelect.getAttribute("data-price"));

    // Get the selected other item and size
    var otherSelect = document.getElementById("ddlOther");
    var otherValue = otherSelect.options[otherSelect.selectedIndex].value;
    var otherPrice = parseFloat(otherSelect.options[otherSelect.selectedIndex].getAttribute("data-price"));

    var otherSizeSelect = document.querySelector('input[name="rbSize2"]:checked');
    var otherSizePrice = parseFloat(otherSizeSelect.getAttribute("data-price"));

    // Calculate the total payment
    var totalPayment = snackPrice + sizePrice + sandwichPrice + sandwichSizePrice + drinkPrice + drinkSizePrice + otherPrice + otherSizePrice;

    // Display the total payment
    var totalPaymentElement = document.getElementById("totalPayment");
    totalPaymentElement.textContent = "$" + totalPayment.toFixed(2);
   
  
}

document.getElementById("btnSubmit").addEventListener("click", calculateTotalPayment);
document.getElementById("btnSubmit3").addEventListener("click", calculateTotalPayment);
document.getElementById("btnSubmit1").addEventListener("click", calculateTotalPayment);
document.getElementById("btnSubmit2").addEventListener("click", calculateTotalPayment);

