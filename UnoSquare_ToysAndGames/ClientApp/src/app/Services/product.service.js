"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
//@Injectable({
//  providedIn: 'root'
//})
var baseUrl = 'http://localhost:44331/api/ToysGames';
var ProductDetailService = /** @class */ (function () {
    function ProductDetailService(http) {
        this.http = http;
    }
    ProductDetailService.prototype.getAll = function () {
        return this.http.get(baseUrl);
    };
    ProductDetailService.prototype.get = function (id) {
        return this.http.get(baseUrl + "/" + id);
    };
    ProductDetailService.prototype.create = function (data) {
        return this.http.post(baseUrl, data);
    };
    ProductDetailService.prototype.update = function (id, data) {
        return this.http.put(baseUrl + "/" + id, data);
    };
    ProductDetailService.prototype.delete = function (id) {
        return this.http.delete(baseUrl + "/" + id);
    };
    return ProductDetailService;
}());
exports.ProductDetailService = ProductDetailService;
//# sourceMappingURL=product.service.js.map