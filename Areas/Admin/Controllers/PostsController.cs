﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GamesSearchAsp.Areas.Admin.Helpers;
using GamesSearchAsp.Areas.Admin.Services;
using GamesSearchAsp.Helpers;
using GamesSearchAsp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamesSearchAsp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostsController : Controller
    {
        private readonly IPostService postService;
        private readonly GameAppDbContext context;

        public PostsController(IPostService postService, GameAppDbContext context)
        {
            this.postService = postService;
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var posts = await postService.GetAllPosts();
            return View(posts);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post post, IFormFile uploadImg, string url)
        {
            try
            {
                if (uploadImg != null)
                {
                    var path = await FileUploadHelper.UploadFile(uploadImg);
                    post.ImageUrl = path;
                    if (ModelState.IsValid)
                    {
                        post.Date = DateTime.Now;
                        await postService.AddPostAsync(post);
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        post.Date = DateTime.Now;
                        var path = await ImageLoader.DownloadFile(url);
                        post.ImageUrl = path;
                        await postService.AddPostAsync(post);
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception)
            {
                TempData["LinkError"] = "Invalid link";
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = context.Posts.Find(id);
            if (post != null)
            {
                return View(post);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Post post, IFormFile uploadImg, string url)
        {
            try
            {
                string path = null;
                if (uploadImg != null)
                {
                    path = await FileUploadHelper.UploadFile(uploadImg);
                    post.ImageUrl = path;
                }
                else if(post.ImageUrl != url)
                {
                    var pathUrl = await ImageLoader.DownloadFile(url);
                    post.ImageUrl = pathUrl;
                }
                post.Date = DateTime.Now;
                await postService.UpdatePostAsync(post);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["LinkError"] = "Invalid link";
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var post = context.Posts.Find(id);
            if (post != null)
            {
                return View(post);
            }
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await postService.RemovePostAsync(id);
            return RedirectToAction("Index");
        }
    }
}