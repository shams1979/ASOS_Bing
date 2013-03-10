Summary

This project has been done using VS2010, .Net4, Moq. I have created an interface called IUrlFetcher that is implemented by UrlFetcher class and uses a normal HttpWebRequest object to get response from a url. Unless there's an error, we return back OK status. 

Being an interface, you can have a different implementation to use the more sophisticated HTMLAgilityPack for parsing and other actions. This interface is being passed into a more concrete Bing class that we use to pass in the search parameters.

I have used TDD approach to make sure the parameters (search url and query) are needed and
we get proper httpstatus back from our request.

I have mocked the interface in the test class to return back ServiceUnavailable status, which would be expected during downtime and this helps us ensure that our program can throw back the correct status.

The RunSearch method allows to run searches multiple times, however it will exit the loop as soon as any httpstatuscode is found besides OK.

Thanks
Shams