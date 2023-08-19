$(document).ready(function () {
    const powerCheckbox = $('#powerCheckbox');
    const rotatingImage = $('#rotatingImage');

    function updateRotatingImageState(isRunning) {
        rotatingImage.css('animation-play-state', isRunning ? 'running' : 'paused');
    }

    function updateSpeedLabel(speed) {
        const speedLabel = $('#speedLabel');
        if (speedLabel.length) {
            speedLabel.text(speed)
                .css('background', 'rgb(255, 140, 26)')
                .css('color', 'rgb(255, 255, 255)');
        }
    }

    function handleCheckboxChange(isChecked) {
        updateRotatingImageState(isChecked);
        if (!isChecked) {
            updateSpeedLabel('Off');
            return;
        }

        handlePowerCheckboxChange(isChecked, function (result) {
            if (result && result.length > 0) {
                const newSpeed = result[0].lastFanSpeed;
                const animationDurationMap = { 'S0': '0s', 'S1': '2.25s', 'S2': '1.5s', 'S3': '0.5s' };
                rotatingImage.css('animation-duration', animationDurationMap[newSpeed]);

                var currentFanSpeedLb;
                switch (newSpeed) {
                case 'S1':
                    currentFanSpeedLb = 'Low';
                    break;
                case 'S2':
                    currentFanSpeedLb = 'Medium';
                    break;
                case 'S3':
                    currentFanSpeedLb = 'High';
                    break;
                case 'S0':
                    currentFanSpeedLb = 'Off';
                    break;
                default:
                    currentFanSpeedLb = 'Unknown';
                }

                updateSpeedLabel(currentFanSpeedLb);
            } else {
                updateSpeedLabel('Off');
            }
        });
    }

    powerCheckbox.on('change', function () {
        handleCheckboxChange(powerCheckbox.prop('checked'));
    });

    $('#PC1Button, #PC2Button').on('click', function () {
        const powerCheckboxChecked = powerCheckbox.prop('checked');
        if (powerCheckboxChecked) {
            const buttonId = $(this).attr('id');
            const speedLabel = $('#speedLabel')[0].innerText; // current speedLevel
            let currentFanSpeed;

            switch (speedLabel) {
                case 'Low':
                    currentFanSpeed = 'S1';
                    break;
                case 'Medium':
                    currentFanSpeed = 'S2';
                    break;
                case 'High':
                    currentFanSpeed = 'S3';
                    break;
                case 'Off':
                    currentFanSpeed = 'S0';
                    break;
                default:
                    currentFanSpeed = 'Unknown';
            }

            if (buttonId === 'PC1Button' || buttonId === 'PC2Button') {
                handleBtnClick(buttonId === 'PC1Button' ? 'P1' : 'P2', currentFanSpeed, function (result) {
                    if (result && result.id > 0) {
                        const newSpeed = result.pullFanSpeedRequest;
                        const animationDurationMap = { 'S0':'0s', 'S1': '2.25s', 'S2': '1.5s', 'S3': '0.5s' };
                        rotatingImage.css('animation-duration', animationDurationMap[newSpeed]);
                        var currentFanSpeedLb;
                        switch (newSpeed) {
                        case 'S1':
                            currentFanSpeedLb = 'Low';
                            break;
                        case 'S2':
                            currentFanSpeedLb = 'Medium';
                            break;
                        case 'S3':
                            currentFanSpeedLb = 'High';
                            break;
                        case 'S0':
                            currentFanSpeedLb = 'Off';
                            break;
                        default:
                            currentFanSpeedLb = 'Unknown';
                        }
                        updateSpeedLabel(currentFanSpeedLb);
                    }
                });
            }
        } else {
            alert("Fan is turned off, please turn the fan on first.");
        }
    });

    function handlePowerCheckboxChange(isChecked, callback) {
        $.ajax({
            type: "GET",
            url: "Index?handler=OnPowerCheckboxChanged",
            data: { "isChecked": isChecked },
            contentType: "application/json",
            success: callback,
            error: function () {
                console.log("Failed to invoke C# method");
            }
        });
    }

    function handleBtnClick(pullCodeId, currentFanSpeed, callback) {
        $.ajax({
            type: "GET",
            url: "Index?handler=OnButtonClickUpdate",
            data: { "pullCodeId": pullCodeId, currentFanSpeed: currentFanSpeed },
            contentType: "application/json",
            success: callback,
            error: function () {
                console.log("Failed to invoke C# method");
            }
        });
    }

    // Initialize the state based on the default checkbox state
    handleCheckboxChange(powerCheckbox.prop('checked'));
});
