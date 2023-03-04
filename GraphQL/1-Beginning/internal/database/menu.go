package database

import (
	"database/sql"

	"github.com/google/uuid"
)

type Menu struct {
	db          *sql.DB
	Id          string
	Name        string
	Description string
}

func (m *Menu) Create(name string, description string) (Menu, error) {
	id := uuid.New().String()

	_, err := m.db.Exec("INSERT INTO menus (id, name, description) VALUES ($1, $2, $3)",
		id, name, description)
	if err != nil {
		return Menu{}, err
	}

	return Menu{Id: id, Name: name, Description: description}, nil
}

func NewMenu(db *sql.DB) *Menu {
	return &Menu{db: db}
}
