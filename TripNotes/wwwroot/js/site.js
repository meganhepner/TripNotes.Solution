$(document).ready(function() {

  $('#test').click(function getFPSData() {
    let alldata = [];
        var raceLength = $(".raceLength").val();
        console.log(raceLength);
        var firstFraction = $(".firstFraction").val();
        console.log(firstFraction);
        var secondFraction = $(".secondFraction").val();
        console.log(secondFraction);
        var thirdFraction = $(".thirdFraction").val();
        console.log(thirdFraction);
    $(".BL").each(function() {
        var HorseRaceId = $(this).find(".joinId").val();
        var BL1 = $(this).find(".BL1").val();
        var BL2 = $(this).find(".BL2").val();
        var BL3 = $(this).find(".BL3").val();
        if (raceLength < 8) {
          let FPS1 = calcSprint1Fr(BL1, firstFraction);
          let FPS2 = calcSprint2Fr(BL1, BL2, secondFraction);
          let FPS3 = calcSprint3Fr(BL2, BL3, thirdFraction, raceLength);
          alldata.push(HorseRaceId, FPS1, FPS2, FPS3);
          } else if (raceLength >= 8) {
            calcRoute1Fr (BL1, firstFraction);
            calcRoute2Fr (BL1, BL2, secondFraction);
            calcRoute3Fr (BL2, BL3, thirdFraction, raceLength);
            alldata.push(HorseRaceId, FPS1, FPS2, FPS3);
            }
          });
    console.log(alldata);
    return alldata;
  });

  function calcSprint1Fr(BL1, firstFraction) {
    let FPS = (1320 - (BL1 * 10)) / firstFraction;
    return FPS;
  }

  function calcSprint2Fr(BL1, BL2, secFraction) {
    let change = (BL1 - BL2);
    let FPS = (1320 + (change * 10)) / secFraction;
    return FPS;
  }

  function calcSprint3Fr(BL2, BL3, thirdFraction, raceLength) {
    let change = (BL2 - BL3);
    let distance = calcDistance(raceLength);
    let FPS = (distance + (change * 10)) / thirdFraction;
    return FPS;
  }

  function calcRoute1Fr(BL1, firstFraction) {
    let FPS = (2640 - (BL1 * 10)) / firstFraction;
    return FPS;
  }

  function calcRoute2Fr(BL1, BL2, secFraction) {
    let change = (BL1 - BL2);
    let FPS = (1320 + (change * 10)) / secFraction;
    return FPS;
  }

  function calcRoute3Fr(BL2, BL3, thirdFraction, raceLength) {
    let change = (BL2 - BL3);
    let distance;
    if (raceLength === 8) {
      distance = 1320;
    } else if (raceLength === 8.18) {
      distance = 1440;
    } else if (raceLength === 8.42) {
      distance = 1520;
    } else if (raceLength === 8.5) {
      distance = 1650;
    } else if (raceLength === 9) {
      distance = 1980;
    } else if (raceLength === 9.5) {
      distance = 2310
    }
    let FPS = (distance + (change * 10)) / thirdFraction;
    return FPS;
  }

  function calcDistance(raceLength) {
    let distance;
    console.log(raceLength);
    if (raceLength === 6) {
      distance = 1320;
    } else if (raceLength === 6.5) {
      distance = 1650;
    } else if (raceLength === 7) {
      distance = 1980;
    }
    console.log(distance);

    return distance;
  }


});