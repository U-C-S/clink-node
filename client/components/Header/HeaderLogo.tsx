import { Title } from "@mantine/core";
import React from "react";

export function Header() {
	return (
		<header>
			<Title
				align="center"
				style={{
					fontFamily: "Amatic SC",
					userSelect: "none",
				}}>
				OverBooked
			</Title>
		</header>
	);
}
