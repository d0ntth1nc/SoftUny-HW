"use strict";

angular
	.module( "VideoSystem" )
	.service( "VideoRepository", function() {
		this.videos = [
			{
				title: 'Course introduction',
				pictureUrl: 'http://www.pictures4cool.com/media/images/picture-wallpaper.jpg',
				length: '3:32',
				category: 'Categoryless',
				subscribers: 6,
				date: new Date(2015, 4, 10),
				haveSubtitles: false,
				likes: 5,
				comments: [
					{
						username: 'Pesho Peshev',
						content: 'Congratulations Nakov',
						date: new Date(2015, 4, 10),
						websiteUrl: 'http://pesho.com/'
					}
				]
			},
			{
				title: 'Angular introduction',
				pictureUrl: 'http://www.pictures4cool.com/media/images/picture-wallpaper.jpg',
				length: '3:31',
				category: 'IT',
				subscribers: 3,
				date: new Date(2015, 4, 9),
				haveSubtitles: true,
				likes: 4,
				comments: [
					{
						username: 'Pesho Peshev',
						content: 'Congratulations Nakov',
						date: new Date(2015, 4, 9),
						websiteUrl: 'http://pesho.com/'
					}
				]
			}
		];
	});