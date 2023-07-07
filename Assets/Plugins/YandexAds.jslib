
mergeInto(LibraryManager.library, {



    ShowRewardsAds: function () {
        ysdk.adv.showRewardedVideo({
            callbacks: {
                onOpen: () => {
                    console.log('Video ad open.');
                },
                onRewarded: () => {
                    console.log('Rewarded!');
                    myGameInstance.SendMessage('Main Camera', 'Rewarded');
                }
            }
        })
  },
    ShowFullScreenAds: function () {
        ysdk.adv.showFullscreenAdv({
            callbacks: {
                onClose: function (wasShown) {
                    console.log('FullScreen ads closed');
                    myGameInstance.SendMessage('Main Camera', 'NoRewarded');
                },
                onError: function (error) {
                    console.log('FullScreen ads error');
                    myGameInstance.SendMessage('Main Camera', 'NoRewarded');
                }
            }
        })
    },
    LoadDistanceExtern: function(){
		player.getData().then(_date => {
				const myJSON = JSON.stringify(_date);
                console.log(myJSON);
				myGameInstance.SendMessage('DistanceCounter', 'LoadDistance', myJSON);
		});
},
    SaveDistanceExtern: function(date){
		var dateString = UTF8ToString(date);
		var myobj = JSON.parse(dateString);
		player.setData(myobj);
},

});