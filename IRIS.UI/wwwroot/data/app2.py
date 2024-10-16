## adiciona CountryId a cada State y a cada City el State del archiivo countries2.json

import json
import os

def get_countries():
    with open('countries2.json') as f:
        data = json.load(f)

    countries = []
    for country in data['countries']:
        country_name = country['name']
        country_id = country['id']
        states = []
        for state in country['states']:
            state_name = state['name']
            state_id = state['id']
            cities = []
            for city in state['cities']:
                city['state_id'] = state_id
                cities.append(city)
            state['cities'] = cities
            state['country_id'] = country_id
            states.append(state)
        country['states'] = states
        countries.append(country)
    return countries

def main():
    countries = get_countries()
    with open('countries3.json', 'w') as f:
        json.dump({'countries': countries}, f, indent=4)
    print("countries3.json updated")

if __name__ == "__main__":
    main()

    