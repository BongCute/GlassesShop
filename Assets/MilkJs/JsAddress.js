/// <reference path="JsController.js" />
var address = {
    changeCity: function (containCity,containDistrict) {
        var cityId = document.getElementById(containCity).value;
        this.district(cityId, containDistrict);
    },
    district: function (cityId, containDistrict)
    {
        var pdata = { cityId: cityId, containDistrict: containDistrict };
        //var pdata = '{cityId:' + (value1) + ', containDistrict:' + (value2) + '}'
        request.get('POST', '/Address/getDistrictList', pdata, function (response) {
            var data = JSON.parse(response.data);
            var selectBox = document.getElementById(response.containDistrict);
            for (i = selectBox.options.length - 1 ; i >= 0 ; i--) {
                selectBox.remove(i);
            }
            for (i = 0; i < data.length; i++) {
                var opt = document.createElement('option');
                opt.value = data[i].MaHuyen;
                opt.innerHTML = data[i].TenHuyen;
                selectBox.appendChild(opt);
                
            }
        }, function () { }, function () { });
    },
    changeDistrict:function(containDistrict,containTown)
    {
        var districtId = document.getElementById(containDistrict).value;
        this.town(districtId, containTown);
    },
    town:function(districtId,containTown){
        var pdata = { districtId: districtId, containTown: containTown };
        //var pdata = '{cityId:' + (value1) + ', containDistrict:' + (value2) + '}'
        request.get('POST', '/Address/getTownList', pdata, function (response) {
            var data = JSON.parse(response.data);
            var selectBox = document.getElementById(response.containTown);
            for (i = selectBox.options.length - 1 ; i >= 0 ; i--) {
                selectBox.remove(i);
            }
            for (i = 0; i < data.length; i++) {
                var opt = document.createElement('option');
                opt.value = data[i].MaXa;
                opt.innerHTML = data[i].TenXa;
                selectBox.appendChild(opt);

            }
        }, function () { }, function () { });
    }
}