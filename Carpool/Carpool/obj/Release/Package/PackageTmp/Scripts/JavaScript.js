    $(document).ready(function ()
    {
        $("#monday").hide();
        $("#tuesday").hide();
        $("#wednesday").hide();
        $("#thursday").hide();
        $("#friday").hide();
        $("#saturday").hide();
        $("#sunday").hide();

        $("#Monday").click(function () {
            if ($(this).is(':checked')) {
                $("#monday").show();
                //$("#InboundStartTime").hide();
                //$("#InboundEndTime").hide();
                //$("#OutboundEndTime").hide();
                //$("#OutboundStartTime").hide();
                //$("#lblEndTime").hide();
                //$("#lblStartTime").hide();
            }

            else {
                $("#monday").hide();
                document.getElementById("MondayStartTime").value = "";
                document.getElementById("MondayEndTime").value = "";
            }
        })
        $("#Tuesday").click(function () {
            if ($(this).is(':checked')) {
                $("#tuesday").show();

            }

            else {
                $("#tuesday").hide();
                document.getElementById("TuesdayStartTime").value = "";
                document.getElementById("TuesdayEndTime").value = "";
            }
        })
        $("#Wednesday").click(function () {
            if ($(this).is(':checked')) {
                $("#wednesday").show();
            }

            else {
                $("#wednesday").hide();
                document.getElementById("WednesdayStartTime").value = "";
                document.getElementById("WednesdayEndTime").value = "";
            }
        })
        $("#Thursday").click(function () {
            if ($(this).is(':checked')) {
                $("#thursday").show();
            }

            else {
                $("#thursday").hide();
                document.getElementById("ThursdayStartTime").value = "";
                document.getElementById("ThursdayEndTime").value = "";
            }
        })
        $("#Friday").click(function () {
            if ($(this).is(':checked')) {
                $("#friday").show();
            }

            else {
                $("#friday").hide();
                document.getElementById("FridayStartTime").value = "";
                document.getElementById("FridayEndTime").value = "";
            }
        })
        $("#Saturday").click(function () {
            if ($(this).is(':checked')) {
                $("#saturday").show();
            }

            else {
                $("#saturday").hide();
                document.getElementById("SaturdayStartTime").value = "";
                document.getElementById("SaturdayEndTime").value = "";
            }
        })
        $("#Sunday").click(function () {
            if ($(this).is(':checked')) {
                $("#sunday").show();
            }

            else {
                $("#sunday").hide();
                document.getElementById("SundayStartTime").value = "";
                document.getElementById("SundayEndTime").value = "";
            }
        })})