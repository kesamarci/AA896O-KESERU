﻿using AutoMapper;
using F1TimeTrialTrack.Data;
using F1TimeTrialTrack.Entities.Dtos.TrackFiles;
using F1TimeTrialTrack.Entities.Dtos.Tracks;
using F1TimeTrialTrack.Entities.Dtos.TracksRating;
using F1TimeTrialTrack.Entities.Dtos.TTs;
using F1TimeTrialTrack.Entities.Dtos.TTsRating;
using F1TimeTrialTrack.Entities.Dtos.User;
using F1TimeTrialTrack.Entities.Entity_Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1TimeTrialTrack.Logic.Helpers
{
    public class DtoProvider
    {
        UserManager<AppUser> userManager;
        public Mapper Mapper { get; }
        public DtoProvider(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Tracks, TrackShortViewDto>()
                .AfterMap((src, dest) =>
                {
                    dest.AvarageRating = src.TracksRatings?.Count > 0 ? src.TracksRatings.Average(r => r.Rating) : 0;
                });
                cfg.CreateMap<AppUser, UserViewDto>()
                .AfterMap((src, dest) =>
                {
                    dest.IsAdmin = userManager.IsInRoleAsync(src, "Admin").Result;
                });
                cfg.CreateMap<Tracks, TrackViewDto>()
                .AfterMap((src, dest) =>
                {
                    dest.Ratings = src.TracksRatings?
                        .Select(r => new TrackRatingViewDto
                        {
                            Rating = r.Rating,
                            Comment = r.Comment,
                            UserFullName = userManager.Users.FirstOrDefault(u => u.Id == r.UserId) != null
                                ? userManager.Users.First(u => u.Id == r.UserId).LastName + " " + userManager.Users.First(u => u.Id == r.UserId).FirstName
                                 : "Ismeretlen"
                        }).ToList();    

                    dest.RatingCount = src.TracksRatings?.Count ?? 0;
                    dest.AverageRating = src.TracksRatings?.Count > 0
                        ? src.TracksRatings.Average(r => r.Rating) : 0;
                });

                cfg.CreateMap<TracksCreateUpdateDto, Tracks>();
                cfg.CreateMap<TrackFile, TrackFileViewDto>();
                cfg.CreateMap<TrackFileCreateDto, TrackFile>();
                cfg.CreateMap<TrackRatingCreateDto, TracksRating>();
                cfg.CreateMap<TracksRating, TrackRatingViewDto>()
                .AfterMap((src, dest) =>
                {
                    var user = userManager.Users.First(u => u.Id == src.UserId);
                    dest.UserFullName = user.LastName! + " " + user.FirstName;
                });
                
                cfg.CreateMap<TTs, TTsViewDto>()
                .AfterMap((src, dest) =>
                {
                    dest.Ratings = src.TTsRatings
                        .Select(r => new TTsRatingViewDto
                        {
                            Rating = r.Rating,
                            Comment = r.Comment,
                            UserFullName = userManager.Users.FirstOrDefault(u => u.Id == r.UserId) != null
                                ? userManager.Users.First(u => u.Id == r.UserId).LastName + " " + userManager.Users.First(u => u.Id == r.UserId).FirstName: "Ismeretlen"
                        }).ToList();

                    dest.RatingCount = src.TTsRatings?.Count ?? 0;
                    dest.AverageRating = src.TTsRatings?.Count > 0
                        ? src.TTsRatings.Average(r => r.Rating) : 0;
                });

                cfg.CreateMap<TTs, TTsShortViewDto>()
                .AfterMap((src, dest) =>
                {
                    dest.AvaerageRating = src.TTsRatings?.Count > 0 ? src.TTsRatings.Average(r => r.Rating) : 0;
                    dest.TimeInMillis = src.TimeInMillis;


                });


                cfg.CreateMap<TTsCCreateUpdateDto, TTs>();
                cfg.CreateMap<TTsRatingCreateDto, TTsRating>();
                cfg.CreateMap<TTsRating, TTsRatingViewDto>()
                .AfterMap((src, dest) =>
                {
                    var user = userManager.Users.First(u => u.Id == src.UserId);
                    dest.UserFullName = user.LastName! + " " + user.FirstName;
                });
            });
            Mapper = new Mapper(config);

        }
    }
}
