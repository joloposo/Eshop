"use client";

import { useEffect, useState } from "react";

type CategoryType = {
  id: number;
  name: string;
  description: string;
};

export default function Home() {
  const [products, setProducts] = useState<CategoryType[]>([]);

  useEffect(() => {
    const loadProducts = async () => {
      const res = await fetch("https://localhost:7153/api/Product");
      const data = await res.json();

      if (res.ok) {
        setProducts(data);
      } else {
        console.error("Failed to fetch products");
      }
    };

    loadProducts();
  }, []);

  return (
    <ul>
      {products.map((x) => {
        return (
          <li key={x.id}>
            {x.id} - {x.name}
          </li>
        );
      })}
    </ul>
  );
}
