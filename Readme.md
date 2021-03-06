# WSPHUOC LIBRARY
## Developed by
- Phan Huu Phuoc
- wsphuoc@gmail.com
## .Net Core 3.1
## Namespace
### wsphuoc.Paging
- Paging models
### wsphuoc.Api
- Api models
### wsphuoc.Recaptcha
- Google ReCaptcha models
### HOW TO USE
View model class
```
public class tinhView
{
    public int id { get; set; }
    public string ten { get; set; }
}
public class PagingRequestBase
{
    public int pageIndex { get; set; } = 1; //current page, begin: 1
    public int pageSize { get; set; } = 20; //rows data per page
    public int pageNums { get; set; } = 5; //page links per page
}
public class tinhPagingRequest:PagingRequestBase
{

}
```
- Return all data as Json
```
[HttpGet]
public async Task<IActionResult> GetAll()
{
    var list = await service.TinhGetAll();
    if (list != null)
    {
        var OkJson = new ApiSuccessResult<List<tinhView>>(list);
        return Ok(OkJson);
    }
    var ErrJson = new ApiErrorResult("Cannot read tinh");
    return Ok(ErrJson);
}
```
- Return data with paging as Json

Method in service
```
public async Task<PagedResult<tinhView>> TinhGetPaging(tinhPagingRequest request)
{
    try
    {
        var q = from x in db.tinhs
                select new tinhView
                {
                    id = x.tinhid,
                    ten = x.ten
                };
        var data = q.ToList();
        var result = new PagedResult<tinhView>(data, request.pageIndex, request.pageSize, request.pageNums);
        return result;
    }
    catch
    {
        return null;
    }
}
```
Method in controller return paging data as Json
```
[HttpGet("paging")]
public async Task<IActionResult> GetPaging([FromQuery]tinhPagingRequest request)
{
    var PagingResult = await service.TinhGetPaging(request);
    if (PagingResult != null)
    {
        var OkJson = new ApiSuccessResult<PagedResult<tinhView>>(PagingResult);
        return Ok(OkJson);
    }
    var ErrJson = new ApiErrorResult("Cannot read tinh");
    return Ok(ErrJson);
}
```