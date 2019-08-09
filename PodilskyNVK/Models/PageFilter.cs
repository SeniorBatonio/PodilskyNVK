using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PodilskyNVK.Models
{
    public static class Pager
    {
        public static NewsViewModel Paging(IEnumerable<Post> posts, int page)
        {
            int pageSize = 10;
            var sortedPosts = posts.OrderByDescending(p => p.CreationDateTime);
            var postsPerPages = sortedPosts.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = sortedPosts.Count() };
            return new NewsViewModel { PageInfo = pageInfo, Posts = postsPerPages };
        }
    }
}