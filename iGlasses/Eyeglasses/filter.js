jQuery(document).ready(function () {

    var lowerSlider = document.getElementById("lower"),
        upperSlider = document.getElementById("upper"),
        lowerTextBox = document.getElementById("lower_tb"),
        upperTextBox = document.getElementById("upper_tb");
    
    lowerVal = parseInt(lowerSlider.value);
    upperVal = parseInt(upperSlider.value);


    upperSlider.oninput = function () {
        lowerVal = parseInt(lowerSlider.value);
        upperVal = parseInt(upperSlider.value);

        if (upperVal < lowerVal + 4) {
            lowerSlider.value = upperVal - 4;

            if (lowerVal == lowerSlider.min) {
                upperSlider.value = 4;
            }
        }

        upperTextBox.value = upperSlider.value;
        lowerTextBox.value = lowerSlider.value;
    };


    lowerSlider.oninput = function () {
        lowerVal = parseInt(lowerSlider.value);
        upperVal = parseInt(upperSlider.value);

        if (lowerVal > upperVal - 4) {
            upperSlider.value = lowerVal + 4;

            if (upperVal == upperSlider.max) {
                lowerSlider.value = parseInt(upperSlider.max) - 4;
            }
        }

        upperTextBox.value = upperSlider.value;
        lowerTextBox.value = lowerSlider.value;
    };
    upperTextBox.value = upperSlider.value;
    lowerTextBox.value = lowerSlider.value;
});