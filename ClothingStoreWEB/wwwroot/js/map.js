function initMap() {
    const mapOptions = {
        zoom: 5,
        center: { lat: 48.3794, lng: 31.1655 },
    };
    const map = new google.maps.Map(document.getElementById("map"), mapOptions);
    const infoWindow = new google.maps.InfoWindow({
        content: "",
        disableAutoPan: true,
    });

    // Create an array of alphabetical characters used to label the markers.
    const labels = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    geocodeAddress(new google.maps.Geocoder(), map, addresses, labels, infoWindow);
}

function geocodeAddress(geocoder, map, addresses, labels, infoWindow) {
    addresses.forEach((address, i) => {
        geocoder.geocode({ address }, (results, status) => {
            if (status === "OK") {
                const location = results[0].geometry.location;
                const marker = new google.maps.Marker({
                    position: location,
                    label: labels[i % labels.length],
                    map: map,
                });

                marker.addListener("click", () => {
                    infoWindow.setContent(address);
                    infoWindow.open(map, marker);
                });
            } else {
                console.warn(`Geocode was not successful for the following reason: ${status}`);
            }
        });
    });
}

window.initMap = initMap;