window.getUserLocation = async function () {
    return new Promise((resolve, reject) => {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(
                (position) => {
                    resolve({
                        Latitude: position.coords.latitude,
                        Longitude: position.coords.longitude
                    });
                },
                (error) => {
                    reject(error);
                }
            );
        } else {
            reject("Geolocation is not supported by this browser.");
        }
    });
};
