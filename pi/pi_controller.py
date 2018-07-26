import requests
import os

ENV_BIKE_ID_KEY = 'BIKE_ID'
#baseUrl = 'http://bike-hack.azurewebsites.net/'
BASE_URL = 'http://localhost:55652/'

# Helper methods.
def get_latitude():
    return '47.6740'

def get_longitude():
    return '122.1215'

def get_battery_percentage():
    return '98'
    
def get_bike_state():
    return 'Idle'

def get_bike_status_json():
    return {'latitude': get_latitude(), 'longitude': get_longitude(), 'batteryPercentage': get_battery_percentage(), 'state': get_bike_state()}

def get_user_id():
    return 'satyan@microsoft.com'

def create_bike():
    url = BASE_URL + 'bikes'
    body = get_bike_status_json()
    response = requests.post(url, json=body)
    return response.json()['bikeId']

def get_bike_id():
    if not os.environ.has_key(ENV_BIKE_ID_KEY):
        os.environ[ENV_BIKE_ID_KEY] = create_bike()
    return os.environ[ENV_BIKE_ID_KEY]


# Main.
bike_id = get_bike_id()
print('retrieved bike id ' + bike_id)