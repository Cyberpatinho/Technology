// Code generated by github.com/99designs/gqlgen, DO NOT EDIT.

package model

type Item struct {
	ID          string  `json:"id"`
	Name        string  `json:"name"`
	Price       float64 `json:"price"`
	Description *string `json:"description"`
	Available   bool    `json:"available"`
	Menu        *Menu   `json:"menu"`
}

type Menu struct {
	ID          string  `json:"id"`
	Name        string  `json:"name"`
	Description *string `json:"description"`
	Items       []*Item `json:"items"`
}

type NewItem struct {
	Name        string  `json:"name"`
	Price       float64 `json:"price"`
	Description *string `json:"description"`
	Available   bool    `json:"available"`
	MenuID      string  `json:"menuId"`
}

type NewMenu struct {
	Name        string  `json:"name"`
	Description *string `json:"description"`
}
