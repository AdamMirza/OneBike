import requests

# Helper methods.
def getLatitude():
    return '47.6740'

def getLongitude():
    return '122.1215'

def getBatteryPercentage():
    return '98'
    
def getBikeState():
    return 'Idle'

def getBikeStatusJson():
    return '{"latitude": ' + getLatitude() + ', "longitude": ' + getLongitude() + ', "batteryPercentage": ' + getBatteryPercentage() + ', "state": "' + getBikeState() + '"}'

def createBike():
    url = baseUrl + 'bikes'
    body = getBikeStatusJson()
    print(body)
    response = requests.post(url, json=body)
    print(response.status_code)
    #print(response.text)


# Main.
baseUrl = "http://bike-hack.azurewebsites.net/"
createBike()