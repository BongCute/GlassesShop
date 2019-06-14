var request = {
    get: function (ptype, purl, pdata, psuccress, pfailure, perror) {
        jQuery.ajax({
            type: ptype,
            url: purl,
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(pdata),
            success: function (response) {
                psuccress(response);
            },
            failure: function (response) {
                pfailure();
            },
            error: function (response) {
                perror();
            },
        });
    },
    put: function (ptype,purl,pdata,psuccress,pfailure,perror) {
        jQuery.ajax({
            type: ptype,
            url: purl,
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(pdata),
            success: function (response) {
                psuccress(response);
            },
            failure: function (response) {
                pfailure();
            },
            error: function (response) {
                perror();
            }
        });
    },
    post: function () {

    },
}
class requester {
    constructor(_sizeOnPage,key,tmpId,containerId) {
        this.keyword = key;
        this.currentPage = 1;
        this._sizeOnPage = _sizeOnPage;
        this.templateId = tmpId;
        this.containerId = containerId;
    }
    init(firstSize,pUrl,pSuccess)
    {
        var pData = {  _sizeOnPage: firstSize,currentPage: this.currentPage, keyword: this.keyword };
        request.get("POST", pUrl, pData, function (response) {
            pSuccess(response);
        }, function () { }, function () { });
    }
    getFollowNumber(pUrl,pSuccess)
    {
        this.currentPage ++;
        var pData = { _sizeOnPage: this._sizeOnPage, currentPage: this.currentPage, keyword: this.keyword };
        request.get("POST", pUrl, pData, function (response) {
            pSuccess(response);
        }, function () { }, function () { });
    }
}